function Delete-BranchProtectionRules {
    param (
        $Rule
    )
    $Rule = $Rules[0]
    $Url = "https://api.github.com/graphql"
    $Id = $Rule.id
    $Pattern = $Rule.pattern
    Write-Information "Deleting branch protection rule"
    $Body = @{
        query = "mutation {
            deleteBranchProtectionRule(input:{branchProtectionRuleId: `"$Id`"}) {
            clientMutationId
            }
        }"
    }

    $Body = $Body | ConvertTo-Json
    $Result = Invoke-RestMethod -Method 'Post' -Uri $Url -Body $Body -Headers $Headers


    if(!$Result.error)
    {
        Write-Information "Success: deleted branch protection rule $Pattern"
    }

}


function Get-BranchProtectionRules {
    param(
        $Headers,
        $RepoName,
        $Org
    )
    $Url = "https://api.github.com/graphql"
    $Body = @{ `
        query = "query GetBranchProtectionRules(`$org: String!, `$repo: String!, `$number_of_rules:Int!) { `
                    repository(owner: `$org, name: `$repo) { `
                            branchProtectionRules(last: `$number_of_rules) { `
                                edges { `
                                    node { `
                                        id `
                                        pattern `
                                        isAdminEnforced `
                                        allowsDeletions `
                                        requiresStatusChecks `
                                        requiresStrictStatusChecks `
                                        dismissesStaleReviews `
                                        restrictsReviewDismissals `
                                        requiredApprovingReviewCount `
                                    } `
                                } `
                            } `
                        } `
                    }"
        operationName = "GetBranchProtectionRules"
        variables = ConvertTo-Json @{ "org" = $Org
                                        "repo" = $RepoName
                                        "number_of_rules" = 4}
    }

    $Body = $Body | ConvertTo-Json
    $Result = Invoke-RestMethod -Method 'Post' -Uri $Url -Body $Body -Headers $Headers
    $Rules = $Result.data.repository.branchProtectionRules.edges.node
    return $Rules
}

function Get-Headers {
    param(
        [Parameter (Mandatory = $TRUE)]
        $GitHubPat
    )
    $headers = @{'Authorization' = "Bearer $GitHubPat" }
    return $headers
}
$env:GitHubPat = "{Github PAT}"
$Headers = Get-Headers $env:GitHubPat
$Rules = Get-BranchProtectionRules

$RepoName = "BlogSamples"
$Org = "IntelliTect-Samples"

# Query and Modify via graphql query
#https://docs.github.com/en/graphql
